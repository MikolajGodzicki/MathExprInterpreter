using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExprInterpreter.MathExpressionTree {
    internal class METNode : IMET {
        public readonly decimal value;

        public METNode(decimal value) {
            this.value = value;
        }

        public decimal Evaluate() {
            return this.value;
        }

        public override string ToString() {
            return value.ToString();
        }
    }
}
