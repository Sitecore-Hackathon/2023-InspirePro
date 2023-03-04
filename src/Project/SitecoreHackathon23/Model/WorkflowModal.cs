using System;
using System.Collections.Generic;
using System.Text;

namespace SitecoreHackathon23.Model
{
    [Serializable]
    public class WorkflowModal
    {
        public string EventName;
        public Item item;
    }
    public class Item
    {
        public string Language { get; set; }
        public int Version { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string TemplateId { get; set; }
        public string MasterId { get; set; }
        public List<object> UnversionedFields { get; set; }
        public List<VersionedField> VersionedFields { get; set; }
    }
    public class VersionedField
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public int Version { get; set; }
        public string Language { get; set; }
    }
}
