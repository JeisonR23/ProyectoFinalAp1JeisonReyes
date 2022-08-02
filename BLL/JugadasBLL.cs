using Microsoft.EntityFrameworkCore;

public class JugadasBLL
{
    private Contexto _contexto;
    public JugadasBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int jugadaId)
    {
        return _contexto.Jugadas.Any(j => j.JugadaId == jugadaId);
    }

    public bool Guardar(Jugadas jugada)
    {
        bool paso = false;

        if (!Existe(jugada.JugadaId))
            paso = Insertar(jugada);
        else
            paso = Modificar(jugada);

        return paso;
    }

    private bool Insertar(Jugadas jugada)
    {
        _contexto.Jugadas.Add(jugada);
        var insertados = _contexto.SaveChanges();
        _contexto.Entry(jugada).State = EntityState.Detached;
        return insertados > 0;
    }

    private bool Modificar(Jugadas jugada)

    {
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM JugadaDetalle WHERE JugadaId={jugada.JugadaId};");
        foreach (var tipoJugada in jugada.Detalle)
        {

            _contexto.Entry(tipoJugada).State = EntityState.Added;

        }
        _contexto.Entry(jugada).State = EntityState.Modified;
        var paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(jugada).State = EntityState.Detached;
        return paso;
    }
    public bool Eliminar(Jugadas jugadas)
    {
        _contexto.Entry(jugadas).State = EntityState.Deleted;
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM JugadaDetalle WHERE JugadaId={jugadas.JugadaId};");
        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(jugadas).State = EntityState.Detached;
        return paso;
    }

    public List<Jugadas> BuscarFecha(DateTime fecha, DateTime fecha2)
    {

        var fechas = _contexto.Jugadas
         .Where(f => f.Fecha.Date == fecha.Date || f.Fecha.Date == fecha2.Date)
         .AsNoTracking().ToList();
        return fechas;
    }

    public Jugadas BuscarJ(int? jugadaId)
    {
        var jugada = _contexto.Jugadas
        .Include(x => x.Detalle)
            .Where(c => c.JugadaId == jugadaId)
            .AsNoTracking()
            .SingleOrDefault();
        return jugada;
    }


    public List<Jugadas> BuscarListaJ(int? jugadaId)
    {
        var jugada = _contexto.Jugadas
        .Include(x => x.Detalle)
            .Where(c => c.JugadaId == jugadaId)
            .AsNoTracking()
            .ToList();
        return jugada;
    }

    public Loterias BuscarL(int? loteriaId)
    {
        var jugada = _contexto.Loterias
            .Where(l => l.LoteriaId == loteriaId)
            .AsNoTracking()
            .SingleOrDefault();
        return jugada;
    }
    public TipoJugada BuscarTJ(int? tipojugadaId)
    {
        var jugada = _contexto.tipoJugada
            .Where(l => l.TipoJugadaId == tipojugadaId)
            .AsNoTracking()
            .SingleOrDefault();

        return jugada;
    }

    public List<Jugadas> GetList()
    {
        return _contexto.Jugadas.AsNoTracking().ToList();
    }

    public List<Loterias> LoteryList()
    {
        return _contexto.Loterias.AsNoTracking().ToList();
    }

    public List<TipoJugada> TypeGame()
    {
        return _contexto.tipoJugada.AsNoTracking().ToList();
    }

}

