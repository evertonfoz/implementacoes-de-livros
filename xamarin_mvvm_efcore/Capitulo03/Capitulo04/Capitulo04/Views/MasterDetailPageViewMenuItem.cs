using System;

namespace Capitulo04.Views
{

    public class MasterDetailPageViewMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }
}