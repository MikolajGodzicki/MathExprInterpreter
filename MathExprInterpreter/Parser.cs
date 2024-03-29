﻿using MathExprInterpreter.MathExpressionTree;
using MathExprInterpreter.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExprInterpreter {
    internal class Parser {
        private List<EToken> TermItems = new List<EToken>() { EToken.Plus, EToken.Minus };
        private List<EToken> FactorItems = new List<EToken>() { EToken.Multiply, EToken.Divide };
        private List<EToken> LevelItems = new List<EToken>() { EToken.Power, EToken.Root };
        private readonly List<Token> tokens;
        private int curPos = 0;
        private Token curToken;


        public Parser(List<Token> tokens) {
            this.tokens = tokens;
            Advance();
        }

        private void Advance() {
            if (curPos < tokens.Count) {
                curToken = tokens[curPos];
                curPos++;
            }
        }

        public IMET ParseExpression() {
            IMET result = Factor();
            while (curToken.type != EToken.EOE && result != null && TermItems.Contains(curToken.type)) {
                if (curToken.type == EToken.Plus) {
                    Advance();
                    IMET rigthNode = Level();
                    result = new METPlus(result, rigthNode);
                }
                else if (curToken.type == EToken.Minus) {
                    Advance();
                    IMET rigthNode = Level();
                    result = new METMinus(result, rigthNode);
                }
            }

            return result;
        }

        public IMET Factor() {
            IMET factor = Level();
            while (curToken.type != EToken.EOE && factor != null && FactorItems.Contains(curToken.type)) {
                if (curToken.type == EToken.Multiply) {
                    Advance();
                    IMET rigthNode = Level();
                    factor = new METMultiply(factor, rigthNode);
                }
                else if (curToken.type == EToken.Divide) {
                    Advance();
                    IMET rigthNode = Level();
                    factor = new METDivide(factor, rigthNode);
                }
            }
            return factor;
        }

        public IMET Level() {
            IMET level = Term();
            while (curToken.type != EToken.EOE && level != null && LevelItems.Contains(curToken.type)) {
                if (curToken.type == EToken.Power) {
                    Advance();
                    IMET rigthNode = Term();
                    level = new METPower(level, rigthNode);
                }
                else if (curToken.type == EToken.Root) {
                    Advance();
                    IMET rigthNode = Term();
                    level = new METRoot(level, rigthNode);
                }
            }
            return level;
        }

        public IMET Term() {
            IMET term = null;

            if (curToken.type == EToken.LeftBracket) {
                Advance();
                term = ParseExpression();
                if (curToken.type != EToken.RightBracket) {
                    throw new FormatException("Missing )");
                }
            }
            else if (curToken.type == EToken.Number) {
                term = new METNode((decimal)curToken.value);
            }

            Advance();
            return term;
        }
    }
}
