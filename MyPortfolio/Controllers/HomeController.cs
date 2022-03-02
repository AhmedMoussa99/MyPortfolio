using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.ViewModels;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolioitem;

        public HomeController(IUnitOfWork<Owner> Owner , IUnitOfWork<PortfolioItem> portfolioitem)
        {
            _owner = Owner;
            _portfolioitem = portfolioitem;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                portfolioItems = _portfolioitem.Entity.GetAll().ToList()
            };
            return View(homeViewModel);
        }
    }
}