using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TwitterPhotos.Controllers
{
    public class TwitterPhotosController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        public TwitterPhotosController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }
        //*
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _cosmosDbService.GetItemsAsync("SELECT * FROM c"));
        }
        //*/
        /*
        public IActionResult Index()
        {
            return View();
        }
        //*/

        // 
        // GET: /TwitterPhotos/



        // 
        // GET: /TwitterPhotos/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}

