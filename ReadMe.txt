---VIEW---
Folder mới "ViewModels"
{
	CourseViewModel.cs
	{
		public DateTime GetDateTime() 
		-- string.Format("{0} {1}",Date,Time) ? --	
	}
}

~/Views/Course/Create.cshtml	Lấy data từ class "CourseViewModel"(CourseViewModel.cs)


---CONTROLLER---
-CoursesController.cs-
{
	private readonly ApplicationDbContext _dbContext;
	--"ApplicationDbContext" là một class trong ApplicationUser.cs--
}

---BUG---
Create.cshtml
{
	-No overload for method-
	@Html.TextBoxFor(m => m.Category, new SelectList(Model.Categories, "Id", "Name"),"", new { @class = "form-control" })
	-Thêm overload cho phương thức "TextBoxFor" ?-
	-- TextBoxFor đổi thành DropDownListFor (viết sai hàm)-- 
}

Github
fatal: The remote end hung up unexpectedly
--cách fix--
git config http.postBuffer 524288000
