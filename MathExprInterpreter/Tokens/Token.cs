using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExprInterpreter.Tokens {
    internal class Token {
        public readonly EToken type;
        public readonly object? value;

        public Token(EToken type, object? value) {
            this.type = type;
            this.value = value;
        }

        public override string ToString() {
            if (value == null) {
                return $"[{type}]";
            }

            return $"[{type} : {value}]";
        }
    }
}
