namespace SuperheroesMvcUI.Models
{
    public class ViewModel : IViewModel
    {
        public List<ISuperheroDisplayModel> SuperheroesDisplay { get; set; }
        public IPageIndex SupeheroroPageIndex { get; set; } = new PageIndexDisplay();
    }
}
