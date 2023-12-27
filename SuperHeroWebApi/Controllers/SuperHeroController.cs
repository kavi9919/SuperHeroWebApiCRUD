using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroWebApi.Models;
using SuperHeroWebApi.Services.SuperHeroService;

namespace SuperHeroWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		private readonly ISuperHeroService _superHeroService;
		//connect service
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
		}




		//get All data
		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
		{

			return await _superHeroService.GetAllHeros();
		}


		//get given Id data
		[HttpGet("{id}")]
		public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
		{
			var result = await _superHeroService.GetSingleHero(id);
			if (result is null)
				return NotFound("hero is not found");
			return Ok(result);
		}



		//post data
		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
		{
			var result = await _superHeroService.AddHero(hero);
			return Ok(result);
		}

		//update data

		[HttpPut("{id}")]
		public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
		{

			var result = await _superHeroService.UpdateHero(id, request);
			if (result is null)
				return NotFound("hero is not found");

			return Ok(result);

		}

		
		
		//delete hero
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
		{

			var result = await _superHeroService.DeleteHero(id);
			if (result is null)
				return NotFound("hero is not found");
			return Ok(result);
		}



		/*private static List<SuperHero> superHeroes = new List<SuperHero>
			{
				new SuperHero
				{
					Id = 1,
					Name="Spider Man",
					FirstName="Peter",
					LastName="Parker",
					Place="New York City"
				},

				new SuperHero
				{
					Id = 2,
					Name="Iron Man",
					FirstName="Tony",
					LastName="Martin",
					Place="New York City"
				}

			};

		//get All data
		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
		{

			return Ok(superHeroes);
		}

		//get given Id data
		[HttpGet("{id}")]
		public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
		{
			var hero = superHeroes.Find(x => x.Id == id);
			if (hero == null)
				return NotFound("Sorry this hero not exists!");
			return Ok(hero);
		}
		//post data
		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
		{
			superHeroes.Add(hero);
			return Ok(hero);
		}


		//update data
		[HttpPut("{id}")]
		public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id ,SuperHero request)
		{

			var hero = superHeroes.Find(x => x.Id == id);
			if (hero == null)
				return NotFound("Sorry this hero not exists!");

				hero.Name = request.Name;
				hero.FirstName=request.FirstName;
				hero.LastName=request.LastName;
				hero.Place=request.Place;


				return Ok(superHeroes);
		}

		 //delete hero
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id, SuperHero request)
		{
			//find the hero by id
			var hero = superHeroes.Find(x => x.Id == id);
			if (hero == null)
				return NotFound("Sorry this hero not exists!");

			superHeroes.Remove(hero);

			return Ok(superHeroes);
		}


		*/

	}
	}
