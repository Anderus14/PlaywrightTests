using Microsoft.Playwright;

namespace Pages
{
	public class VerifyTextPage
	{
		private IPage _page;
		public ILocator PageLabel => _page.Locator("//h3[text()='Verify Text']");
		public ILocator HelloUsernameText => _page.Locator("//span[@class='badge-secondary' and text()='Hello UserName!']");

		public VerifyTextPage(IPage page)
		{
			_page = page;
			_page.WaitForURLAsync("**/verifytext");
		}
	}
}