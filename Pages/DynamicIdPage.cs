using Microsoft.Playwright;

namespace Pages
{
	public class DynamicIdPage
	{
		private IPage _page;
		public ILocator PageLabel => _page.Locator("//h3[text()='Dynamic ID']");
		public ILocator DynamicIdButton => _page.GetByText("Button with Dynamic ID");
	
		public DynamicIdPage(IPage page)  
		{
			_page = page;
			_page.WaitForURLAsync("**/dynamicid");
		}
	}
}