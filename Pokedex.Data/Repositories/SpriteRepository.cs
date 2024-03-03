using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pokedex.Core.Entities;
using Pokedex.Data.Context;

namespace Pokedex.Data.Repositories;

public class SpriteRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger _logger;

    public SpriteRepository(
        AppDbContext context,
        ILogger<SpriteRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Sprite>> GetSprites()
    {
        try
        {
            return await _context.Sprites
                .AsNoTracking()
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<Sprite?> GetSpriteById(int id)
    {
        try
        {
            return await _context.Sprites
                .AsNoTracking()
                    .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<Sprite?> PostSprite(Sprite sprite)
    {
        try
        {
            sprite.CreateDate = DateTime.Now;
            sprite.UpdateDate = DateTime.Now;
            sprite.Enabled = true;

            _context.Sprites.Add(sprite);
            await _context.SaveChangesAsync();
            return sprite;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<Sprite?> PutSprite(Sprite sprite)
    {
        try
        {
            Sprite? spriteExists = await _context.Sprites.Where(x => x.Id == sprite.Id).FirstOrDefaultAsync();
            if (spriteExists != null)
            {
                spriteExists.Url = sprite.Url;
                spriteExists.UpdateDate = sprite.UpdateDate;
                spriteExists.Enabled = sprite.Enabled;

                _context.Sprites.Update(spriteExists);
                await _context.SaveChangesAsync();
                return spriteExists;
            }

            return new Sprite();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<bool> RemoveSprite(int id)
    {
        try
        {
            Sprite? spriteExists = await _context.Sprites.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (spriteExists != null)
            {
                _context.Sprites.Remove(spriteExists);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }
}
