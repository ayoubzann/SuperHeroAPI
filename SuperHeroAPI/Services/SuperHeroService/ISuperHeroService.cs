namespace SuperHeroAPI.Services.SuperHeroService
{
    public class ISuperHeroService
    {
        List<SuperHero> AddHero(SuperHero hero);

        List<SuperHero> GetAllHeroes();
        SuperHero GetHeroById(int id);
        List<SuperHero> UpdateHero(int id, SuperHero request);
    }
}
