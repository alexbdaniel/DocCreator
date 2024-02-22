using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager.Tests;

[TestClass()]
public class PreparationTests
{
	[TestMethod()]
	public void BuildDocArgsTest()
	{
		Assert.Fail();
	}

	[TestMethod()]
	public async Task GetDocArgsFromFileAsyncTest()
	{
		const string fullPath = "C:\\Users\\Alex.Daniel\\Projects\\doc_creator_2\\DocCreator\\WordManagerTests2\\testArgsArray.json";

		
		var result = await new Preparation().GetDocArgsListFromFileAsync(fullPath);

		return;

		
	}
}