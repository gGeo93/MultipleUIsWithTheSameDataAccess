
namespace SuperheroesMvcUI.Models
{
    public interface IViewModel
    {
        List<ISuperheroDisplayModel> SuperheroesDisplay { get; set; }
        IPageIndex SupeheroroPageIndex { get; set; }
    }
}