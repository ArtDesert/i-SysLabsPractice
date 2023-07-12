using DomainLayer.Entities.Models;
using DomainLayer.Enums;

namespace DomainLayer.TableInitializators
{
	public static class StatusInitializator // undone
	{
        static StatusInitializator()
        {
            
        }

		public async static Task TryInitializeAsync(CompanyStructureContext context)
		{
			var statuses = Enumerable.Range(0, 5).Select(x => (StatusToken)x);
			foreach (var status in statuses)
			{
				var exist = context.Statuses.FirstOrDefault(x => x.Name == status);
				if (exist == null)
				{
					var newStatus = new Status() { Name = status };
					await context.AddAsync(newStatus);
				}
			}
			await context.SaveChangesAsync();
		}
	}
}
