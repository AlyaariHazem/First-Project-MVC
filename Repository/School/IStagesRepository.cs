using System;
using Backend.Models;
using FirstProjectWithMVC.ViewModels;

namespace FirstProjectWithMVC.Repository;

public interface IStagesRepository:IgenericRepository<Stage>
{
    public void Add(AddStageViewModel obj);
    public void Update(AddStageViewModel obj);
     public void Save();
    public List<StagesViewModel> DisplayStages();
    
}
