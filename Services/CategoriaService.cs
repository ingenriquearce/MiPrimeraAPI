using webapi;
using webapi.Models;

public class CategoriaService : ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    //This method is to save changes
    public async Task Save(Categoria categoria)
    {
        /*context.Add(categoria);
        context.SaveChanges();*/

        //Another way to do it with an async method
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }
}


public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}      