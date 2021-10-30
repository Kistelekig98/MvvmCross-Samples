using Foundation;
using MvvmCross.iOS.Support.Views;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace Collections.Touch
{
  public class BaseExpandableTableView : MvxTableViewController
  {
    protected ExpandableTableSource source;

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();

      source = new ExpandableTableSource(TableView)
      {
        UseAnimations = true,
        AddAnimation = UITableViewRowAnimation.Left,
        RemoveAnimation = UITableViewRowAnimation.Right
      };

      TableView.RowHeight = 120f;
      TableView.Source = source;
    }
  }

  public class ExpandableTableSource : MvxExpandableTableViewSource
  {
    private readonly NSString cellIdentifier;
    protected virtual NSString CellIdentifier => cellIdentifier;

    private readonly NSString headerCellIdentifier;
    protected virtual NSString HeaderCellIdentifier => headerCellIdentifier;

    public ExpandableTableSource(UITableView tableView) : base(tableView)
    {
      string nibName = "KittenCell";
      cellIdentifier = new NSString(nibName);
      tableView.RegisterNibForCellReuse(UINib.FromName(nibName, NSBundle.MainBundle), CellIdentifier);

      string nibName2 = "HeaderCell";
      headerCellIdentifier = new NSString(nibName2);
      tableView.RegisterNibForCellReuse(UINib.FromName(nibName2, NSBundle.MainBundle), HeaderCellIdentifier);
    }

    protected override UITableViewCell GetOrCreateHeaderCellFor(UITableView tableView, nint section)
      => tableView.DequeueReusableCell(HeaderCellIdentifier);

    protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
      => tableView.DequeueReusableCell(CellIdentifier);
  }
}
