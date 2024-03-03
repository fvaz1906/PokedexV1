using Pokedex.Core.Entities;
using Pokedex.Core.Helpers;

namespace Pokedex.Service.Interfaces;

public interface ISpriteService
{
    public Task<Pagination<Sprite>> GetSprites(int page, int pageSize);
    public Task<Sprite?> GetSpriteById(int id);
    public Task<Sprite?> PostSprite(Sprite sprite);
    public Task<Sprite?> PutSprite(Sprite sprite);
    public Task<bool> RemoveSprite(int id);
}
