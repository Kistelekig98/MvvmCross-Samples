using Collections.Core.ViewModels.Samples.ListItems;
using System.Collections.Generic;

namespace Collections.Core
{
  public class KittenGroup : List<Kitten>
	{
		public string Title { get; set; }
		public KittenGroup(IEnumerable<Kitten> collection) : base(collection) { }
	}
}
