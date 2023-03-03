using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExprInterpreter.MathExpressionTree {
    internal class METMinus : IMET {
        public readonly IMET leftNode;
        public readonly IMET rightNode;

        public METMinus(IMET leftNode, IMET rightNode) {
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }

        public decimal Evaluate() {
            return leftNode.Evaluate() - rightNode.Evaluate();
        }

        public override string ToString() {
            return $"{leftNode.Evaluate()} - {rightNode.Evaluate()}";
        }
    }
}
