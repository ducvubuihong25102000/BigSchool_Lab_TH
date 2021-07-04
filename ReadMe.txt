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
[Done]
Create.cshtml
{
	-No overload for method-
	@Html.TextBoxFor(m => m.Category, new SelectList(Model.Categories, "Id", "Name"),"", new { @class = "form-control" })
	-Thêm overload cho phương thức "TextBoxFor" ?-
	-- TextBoxFor đổi thành DropDownListFor (viết sai hàm)-- 
}

[Done]
public ActionResult Index()
{
  var upcomingCourses = _dbContext.Courses
 	.Include(c => c.Lecturer) 	***nội dung "c=>c.Lecturer" bị lỗi cant convert lambda expression to string**
 	.Include(c => c.Category)
	.Where(c => c.DateTime > DateTime.Now);
	return View(upcomingCourses);
}
--Fix bằng cách thêm thư viện "using System.Data.Entity;"
--Có cùng hàm Include trong 1 thư viện khác
--> Tìm hiểu thư viện 	

[Done]
Github
fatal: The remote end hung up unexpectedly
--cách fix--
git config http.postBuffer 524288000

[Not Done]
Không add dc css Content/Site.css vào file Views/Home/index.cshtml ( trang 52)