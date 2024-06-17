/*
    뷰 구성요소 메서드
    Task<IViewComponentResult>를 반환하는 InvokeAsync 메서드입니다.
    IViewComponentResult를 반환하는 Invoke 동기 메서드입니다.

    보기 검색 경로
    런타임은 다음 경로에서 뷰를 검색합니다.
    
    /Views/{Controller Name}/Components/{View Component Name}/{View Name}
    /Views/Shared/Components/{View Component Name}/{View Name}
    /Pages/Shared/Components/{View Component Name}/{View Name}
    /Areas/{Area Name}/views/Shared/Components/{View Component Name}/{View Name}

    보기 구성 요소에 대한 기본 보기 이름은 Default이며, 이는 일반적으로 보기 파일의 이름이 Default.cshtml로 지정됨을 의미합니다. 보기 구성 요소 결과를 만들거나 View 메서드를 호출할 때 다른 보기 이름을 지정할 수 있습니다.

    보기 파일 이름을 Default.cshtml로 지정하고 Views/Shared/Components/{View Component Name}/{View Name} 경로를 사용하는 것이 좋습니다. PriorityList 이 샘플에서 사용되는 뷰 구성 요소는 뷰 구성 요소 뷰에 사용됩니다Views/Shared/Components/PriorityList/Default.cshtml.

    https://learn.microsoft.com/ko-kr/aspnet/core/mvc/views/view-components?view=aspnetcore-8.0
*/

using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultBrandComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
