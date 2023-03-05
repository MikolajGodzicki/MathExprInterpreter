using MathExprInterpreter.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExprInterpreter {
    internal class Lexer {
        private List<Token> tokens;
        private string input;
        private int curPos = 0;
        private char curChar;

        private List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };

        public Lexer(string input) {
            this.input = input; 
            this.tokens = new List<Token>();
            this.curChar = input.Length == 0 ? '\0' : input[curPos];
        }

        public void Advance() {
            if (curPos < input.Length - 1) {
                curPos++;
                curChar = input[curPos];
            } else {
                curChar = '\0';
            }
        }

        public List<Token> GetTokens() {
            while (true) {
                if (curChar == ' ' || curChar == '\t') {
                    Advance();
                    continue;
                }
                else if (numbers.Contains(curChar)) {
                    Token numberToken = Generate_Number();
                    tokens.Add(numberToken);
                }
                else if (curChar == '+') {
                    Token plusToken = new Token(EToken.Plus, null);
                    tokens.Add(plusToken);
                    Advance();
                }
                else if (curChar == '-') {
                    Token minusToken = new Token(EToken.Minus, null);
                    tokens.Add(minusToken);
                    Advance();
                }
                else if (curChar == '*') {
                    Token multiplyToken = new Token(EToken.Multiply, null);
                    tokens.Add(multiplyToken);
                    Advance();
                }
                else if (curChar == '/') {
                    Token divideToken = new Token(EToken.Divide, null);
                    tokens.Add(divideToken);
                    Advance();
                }
                else if (curChar == '^') {
                    Token powerToken = new Token(EToken.Power, null);
                    tokens.Add(powerToken);
                    Advance();
                }
                else if (curChar == '#') {
                    Token rootToken = new Token(EToken.Root, null);
                    tokens.Add(rootToken);
                    Advance();
                }
                else if (curChar == '(') {
                    Token leftBracketToken = new Token(EToken.LeftBracket, null);
                    tokens.Add(leftBracketToken);
                    Advance();
                }
                else if (curChar == ')') {
                    Token rightBracketToken = new Token(EToken.RightBracket, null);
                    tokens.Add(rightBracketToken);
                    Advance();
                }
                else if (curChar == '\0') {
                    tokens.Add(new Token(EToken.EOE, null));
                    break;
                }
                else {
                    Advance();
                }
            }

            return tokens;
        }

        private Token Generate_Number() {
            int decimal_count = 0;
            string mem = "";

            while (numbers.Contains(curChar)) {
                if (curChar == '.' && decimal_count <= 1) {
                    decimal_count++;
                }

                if (mem.Length < 1 && decimal_count > 0) {
                    mem += "0";
                }

                mem += curChar == '.' ? ',' : curChar;
                Advance();
            }

            decimal value = Convert.ToDecimal(mem);
            return new Token(EToken.Number, value);
        }

        public override string ToString() {
            string mem = "";

            foreach (Token token in tokens) {
                mem += token.ToString();
            }

            return mem;
        }
    }
}
