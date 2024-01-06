using System.Runtime.CompilerServices;
using Microsoft.Playwright;

namespace PlaywrightTests
{
	public class DynamicIdPage
	{
		private static IPage _page;
		public ILocator PageLabel() => _page.Locator("//h3[text()='Dynamic ID']");
		public ILocator DynamicIdButton() => _page.GetByText("Button with Dynamic ID");
	
		public DynamicIdPage(IPage page) => _page = page;
	}
}