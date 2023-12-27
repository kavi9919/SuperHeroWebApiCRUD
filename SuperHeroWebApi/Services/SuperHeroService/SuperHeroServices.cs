using Microsoft.EntityFrameworkCore;
using SuperHeroWebApi.Data;
using SuperHeroWebApi.Models;

namespace SuperHeroWebApi.Services.SuperHeroService
{
	public class SuperHeroServices : ISuperHeroService
	{
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

			};*/


		private readonly DataContext _context;
        public SuperHeroServices(DataContext context)
        {
			_context = context;
		}

		public DataContext Context { get; }


		//get all data
		public async Task<List<SuperHero>> GetAllHeros()
		{

			var heroes = await _context.SuperHeroes.ToListAsync(); //retrieve data from db
			return heroes;
		}

		//get single data by id
		public async Task<SuperHero?> GetSingleHero(int id)
		{
			var hero = await _context.SuperHeroes.FindAsync(id);  //find data from db
			if (hero == null)
				return null;
			return hero;
		}


        //add
		public async Task<List<SuperHero>> AddHero(SuperHero hero)
		{
			Context.SuperHeroes.Add(hero);
			await _context.SaveChangesAsync();
			return await _context.SuperHeroes.ToListAsync();
		}

	
		//update
		public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
		{
			var hero = await _context.SuperHeroes.FindAsync(id); //find data from db
			if (hero == null)
				return null;

			hero.Name = request.Name;
			hero.FirstName = request.FirstName;
			hero.LastName = request.LastName;
			hero.Place = request.Place;

			await _context.SaveChangesAsync();


			return await _context.SuperHeroes.ToListAsync();
		}
		
		//delete
		public async Task<List<SuperHero>?> DeleteHero(int id)
		{
			var hero = await _context.SuperHeroes.FindAsync(id); //find data from db
			if (hero == null)
				return null;

			_context.SuperHeroes.Remove(hero);

			await _context.SaveChangesAsync();
			return await _context.SuperHeroes.ToListAsync();
		}
	}
}
