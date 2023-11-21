using LinkShorteningSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using LinkShorteningSite.Core.DTOs;
using LinkShorteningSite.Core.Interfaces.Services;

namespace LinkShorteningSite.Controllers
{
    public class UrlController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUrlService _urlService;

        public UrlController(IMapper mapper, IUrlService urlService)
        {
            _mapper = mapper;
            _urlService = urlService;
        }

        public async Task<IActionResult> Index()
        {
            var listUrlDto = await _urlService.GetAllUrlsAsync();
            var listViewModel = _mapper.Map<IEnumerable<UrlViewModel>>(listUrlDto);

            return View(listViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var urlCreateViewModel = new UrlCreateViewModel();

            return View(urlCreateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UrlCreateViewModel viewModel)
        {
            try
            {
                var urlDto = _mapper.Map<UrlDto>(viewModel);

                await _urlService.CreateUrlAsync(urlDto);

                if (viewModel != null)
                {
                    return RedirectToAction("Index", "Url");
                }

                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                //Log.Fatal(e, $"{e.Message} \n Stack trace:{e.StackTrace}");

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var urlDto = await _urlService.GetUrlByIdAsync(id);
                var viewModel = _mapper.Map<UrlViewModel>(urlDto);

                if (viewModel != null)
                {
                    return View(viewModel);
                }

                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {

                //Log.Fatal(e, $"{e.Message} \n Stack trace:{e.StackTrace}");

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UrlViewModel viewModel)
        {
            try
            {
                await _urlService.DeleteUrlByIdAsync(viewModel.Id);

                if (viewModel != null)
                {
                    return RedirectToAction("Index", "Url");
                }

                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {

                //Log.Fatal(e, $"{e.Message} \n Stack trace:{e.StackTrace}");

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            try
            {
                var urlDto = await _urlService.GetUrlByIdAsync(id);
                var urlEditViewModel = _mapper.Map<UrlEditViewModel>(urlDto);

                if (urlDto != null)
                {
                    return View(urlEditViewModel);
                }

                else
                {
                    throw new ArgumentException();
                }

            }
            catch (Exception e)
            {
                //Log.Fatal(e, $"{e.Message} \n Stack trace:{e.StackTrace}");

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UrlEditViewModel viewModel)
        {
            try
            {

                await _urlService.UpdateUrlAsync(viewModel.Id, viewModel.ShortUrl, viewModel.DateCreated);

                if (viewModel != null)
                {
                    return RedirectToAction("Index", "Url");
                }

                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                //Log.Fatal(e, $"{e.Message} \n Stack trace:{e.StackTrace}");

                return BadRequest();
            }
        }
    }
}
