using Microsoft.Playwright;

namespace Pages
{
	public class DynamicTable
	{
		private IPage _page;
		public ILocator TableElements => _page.Locator("//div[@role='rowgroup'][2]/div[@role='row']");

		public DynamicTable(IPage page)
		{
			_page = page;
			_page.WaitForURLAsync("**/dynamictable");
		}
	}
}