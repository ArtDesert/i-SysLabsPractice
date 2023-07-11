using DomainLayer.Entities.Models;
using static DomainLayer.Enums.StatusToken;

namespace DomainLayer.TableInitializators
{
	public class StatusInitializator : IStatusInitializator
	{
		private static StatusInitializator instance;

		public StatusInitializator(CompanyStructureContext context)
		{
			_context = context;
		}

		public static IStatusInitializator GetInstance(CompanyStructureContext context)
		{
			if (instance == null)
			{
				instance = new StatusInitializator(context);
			}
			return instance;
		}

		private readonly CompanyStructureContext _context;

		public bool IsInitialized { get; set; }

		public void TryInitialize()
		{
			if (!IsInitialized)
			{
				_context.Statuses.Add(new Status() { StatusToken = Active });
				_context.Statuses.Add(new Status() { StatusToken = OnHoliday });
				_context.Statuses.Add(new Status() { StatusToken = Dismissed });
				_context.Statuses.Add(new Status() { StatusToken = Hospital });
				_context.Statuses.Add(new Status() { StatusToken = InDecree });
				_context.SaveChanges();
				IsInitialized = true;
			}
		}
	}

	public interface IBaseInitializator
	{
		bool IsInitialized { get; set; }
		void TryInitialize();
	}

	public interface IStatusInitializator : IBaseInitializator
	{
		new bool IsInitialized { get; }
	}
}
