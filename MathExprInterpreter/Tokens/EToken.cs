using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExprInterpreter.Tokens
{
    internal enum EToken
    {
        Number,

        Plus, // +
        Minus, // -
        Multiply, // *
        Divide, // \

        LeftBracket, // (
        RightBracket, // )

        EOE // End Of Expression
    }
}
