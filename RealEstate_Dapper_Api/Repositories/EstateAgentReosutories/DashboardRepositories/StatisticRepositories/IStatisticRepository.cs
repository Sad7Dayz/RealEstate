namespace RealEstate_Dapper_Api.Repositories.EstateAgentReosutories.DashboardRepositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int ProductCountByEmployeeId(int id);
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();

    }
}
