using Microsoft.EntityFrameworkCore;

public class GananciasBLL
{
    private Contexto _contexto;
    public GananciasBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int gananciaId)
    {
        return _contexto.Ganancias.Any(g => g.GananciaId == gananciaId);
    }

    public bool Guardar(Ganancias ganancias)
    {
        bool paso = false;

        if (!Existe(ganancias.GananciaId))
            paso = Insertar(ganancias);
        else
            paso = Modificar(ganancias);

        return paso;
    }

    private bool Insertar(Ganancias ganancias)
    {
        _contexto.Ganancias.Add(ganancias);
        var insertados = _contexto.SaveChanges();
        _contexto.Entry(ganancias).State = EntityState.Detached;
        return insertados > 0;
    }

    private bool Modificar(Ganancias ganancias)
    {

        _contexto.Database.ExecuteSqlRaw($"DELETE FROM GananciaDetalle WHERE GananciaId={ganancias.GananciaId};");
        foreach (var ganancia in ganancias.Detalle)
        {

            _contexto.Entry(ganancia).State = EntityState.Added;

        }

        _contexto.Entry(ganancias).State = EntityState.Modified;

        var paso = _contexto.SaveChanges() > 0;

        _contexto.Entry(ganancias).State = EntityState.Detached;

        return paso;
    }
    public bool Eliminar(Ganancias ganancias)
    {
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM GananciaDetalle WHERE GananciaId={ganancias.GananciaId};");
        _contexto.Entry(ganancias).State = EntityState.Deleted;
        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(ganancias).State = EntityState.Detached;
        return paso;
    }

    public List<Ganancias> Buscar(DateTime fecha, DateTime fecha2)
    {

        var fechas = _contexto.Ganancias
         .Where(f => f.Fecha.Date == fecha.Date || f.Fecha.Date == fecha2.Date)
         .AsNoTracking().ToList();
        return fechas;
    }

    public Loterias BuscarL(int? loteriaId)
    {
        var jugada = _contexto.Loterias
            .Where(l => l.LoteriaId == loteriaId)
            .AsNoTracking()
            .SingleOrDefault();
        return jugada;
    }




    public Ganancias BuscarJ(int? gananciaId)
    {
        var ganancia = _contexto.Ganancias
        .Include(x => x.Detalle)
            .Where(c => c.GananciaId == gananciaId)
            .AsNoTracking()
            .SingleOrDefault();
        return ganancia;
    }

    public TipoJugada BuscarTJ(int? tipojugadaId)
    {
        var jugada = _contexto.tipoJugada
            .Where(l => l.TipoJugadaId == tipojugadaId)
            .AsNoTracking()
            .SingleOrDefault();

        return jugada;
    }

    public List<Ganancias> BuscarListaJ(int? gananciaId)
    {
        var ganancia = _contexto.Ganancias
        .Include(x => x.Detalle)
            .Where(c => c.GananciaId == gananciaId)
            .AsNoTracking()
            .ToList();
        return ganancia;
    }


    public List<Ganancias> GetList()
    {
        return _contexto.Ganancias.AsNoTracking().ToList();
    }
}

