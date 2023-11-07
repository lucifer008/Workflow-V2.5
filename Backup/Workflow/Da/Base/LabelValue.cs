using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Da.Domain
{
    public class LabelValue
    {
        public LabelValue(String value, String label)
        {
            this.value = value;
            this.label = label;
        }
        private string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private string label;

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

    }
}
