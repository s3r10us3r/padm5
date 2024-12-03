namespace padm5.ViewModels.Interfaces
{
    public interface INavigationManager
    {
        Task NavigateToDepartmentList();
        Task NavigateToNewDepartment();
        Task NavigateToError();
        Task NavigateToNotFound();
        Task NavigateToDepartmentDetails(int id);
        Task NavigateEditDepartment(int id);
        Task NavigateToTeamDetails(int id);
        Task NavigateToNewTeam(int departmentId);
        Task NavigateToEditTeam(int id);
        Task NavigateToWorkerList();
        Task NavigateToWorkerDetails(int id);
        Task NavigateToEditWorker(int id);
        Task NavigateToNewWorker();
    }
}
