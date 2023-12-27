using SuperHeroWebApi.Models;

namespace SuperHeroWebApi.Services.SuperHeroService
{

	//add services interface
	public interface ISuperHeroService
	{
		Task<List<SuperHero>> GetAllHeros();
		Task<SuperHero?> GetSingleHero(int id);

		Task<List<SuperHero>> AddHero(SuperHero hero);

		Task<List<SuperHero>?> UpdateHero(int id, SuperHero request);

		Task<List<SuperHero>?> DeleteHero(int id);

	}
}
