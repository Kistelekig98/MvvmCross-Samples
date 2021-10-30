using System.Collections.Generic;
using System.Linq;
using Collections.Core.ViewModels.Samples.Expandable;
using MvvmCross.Core.Navigation;

[assembly: MvxNavigation(typeof(ExpandableViewModel), nameof(ExpandableViewModel))]
namespace Collections.Core.ViewModels.Samples.Expandable
{
  public class ExpandableViewModel : BaseSampleViewModel
  {
    private List<KittenGroup> kittenGroups;
    public List<KittenGroup> KittenGroups

    {
      get => kittenGroups;
      set => SetProperty(ref kittenGroups, value);
    }

    public ExpandableViewModel() => KittenGroups = CreateKittenGroups(10).ToList();
  }
}
