
namespace SuperheroesMvcUI.Models
{
    public interface IViewModel
    {
        List<ISuperheroDisplayModel> SuperheroesDisplay { get; set; }
        IPageIndex SupeheroPageIndex { get; set; }
    }
}