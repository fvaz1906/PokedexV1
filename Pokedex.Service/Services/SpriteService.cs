using Pokedex.Core.Entities;
using Pokedex.Core.Helpers;
using Pokedex.Data.Repositories;
using Pokedex.Service.Interfaces;

namespace Pokedex.Service.Services;

public class SpriteService : ISpriteService
{
    private readonly SpriteRepository _spriteRepository;

    public SpriteService(SpriteRepository spriteRepository)
    {
        _spriteRepository = spriteRepository;
    }

    public async Task<Pagination<Sprite>> GetSprites(
        int page,
        int pageSize)
    {
        List<Sprite> sprites = await _spriteRepository.GetSprites();

        return new Pagination<Sprite>
        {
            Data = sprites.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            Page = page,
            PageSize = pageSize,
            TotalItems = sprites.Count()
        };

    }

    public async Task<Sprite?> GetSpriteById(int id)
    {
        return await _spriteRepository.GetSpriteById(id);
    }

    public async Task<Sprite?> PostSprite(Sprite sprite)
    {
        return await _spriteRepository.PostSprite(sprite);
    }

    public async Task<Sprite?> PutSprite(Sprite sprite)
    {
        return await _spriteRepository.PutSprite(sprite);
    }

    public async Task<bool> RemoveSprite(int id)
    {
        return await _spriteRepository.RemoveSprite(id);
    }
}
