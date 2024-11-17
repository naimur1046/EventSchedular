using EventSchedulerImplementaion.Models.Entity;
using FluentNHibernate.Mapping;

namespace EventSchedulerImplementaion.Models.Mapping
{
    public class EventMapping : ClassMap<Event>
    {
        public EventMapping()
        {
            Table("Event");
            Id(x => x.EventId).GeneratedBy.Identity();
            Map(x => x.Title).Not.Nullable();
            Map(x => x.Description).Nullable();
            Map(x => x.StartDateTime).Not.Nullable();
            Map(x => x.EndDateTime).Not.Nullable();
            Map(x => x.Location).Nullable();
            Map(x => x.IsAllDay).Not.Nullable();
            Map(x => x.CreatedBy).Not.Nullable();
            Map(x => x.CreatedDate).Not.Nullable();
            Map(x => x.UpdatedDate).Not.Nullable();
        }
    }

}



