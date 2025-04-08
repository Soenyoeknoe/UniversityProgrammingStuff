#include <iostream>
#include <vector>
#include <stack>
#include <map>
#include <string>
#include <algorithm>
#include "calc.hpp"

int mathematicalPrecedence(char mdas) { // fuction to check the mathematical precedence
 if(mdas == '*' || mdas == '/'){// both '*' and '/' have equal precedence and highest precedence to calculate
    return 3;
  } else if(mdas == '+' || mdas == '-'){// both '+' and '-' have equal precedence to calculate
    return 2;
  } else { //or else it will give the lowest precedence to calculate
    return 1;
  } 
}
std::vector<Calc::Token> Calc::infixToPostfix(const std::vector<Token>& input) {//time complexity for this function is O(n) as n is the size of the input vector and it iterates over each element of the input vector once.
  std::vector<Token> giveOutput;  //declare a vector of Tokens output
  std::stack<Token> daOperatorStack; //declare vector of Tokens operatorStack
  std::vector<Token>::size_type tkn = -1; //declare static member type of the type vector<Token> to count the index of token t in the input
  tkn++; //add the static member of tkn
  while(tkn < input.size()) {
    Token daTokens = input[tkn];//if tkn is less then the input it will loops and check its token in the input and increment to tkn as the input index
    if(daTokens.type == 'n') {// if the token is a number, push it back to the output;
      giveOutput.push_back(daTokens);
      tkn++;
      continue;
    } else if(daOperatorStack.empty() || daTokens.type == '(') {//check if its empty or the token is '(',
        daOperatorStack.push(daTokens);
        tkn++;
        continue;
    } else if(daTokens.type == ')') {
        for (; daOperatorStack.top().type != '('; daOperatorStack.pop()) {
          giveOutput.push_back(daOperatorStack.top());
          }
        daOperatorStack.pop(); 
        tkn++;
        continue;
    }
    if(mathematicalPrecedence(daOperatorStack.top().type) < mathematicalPrecedence(daTokens.type)){// basically it check the mathematical predecence of the top of the stack daOperatorStack check is lower precedence of token to pop operatorstack and and push to output
      daOperatorStack.push(daTokens);
      tkn++;
    } else {
        for (; !daOperatorStack.empty() && mathematicalPrecedence(daOperatorStack.top().type) >= mathematicalPrecedence(daTokens.type); daOperatorStack.pop()) { //basiacally it loops through the daOperatorStack to check if its empty and top of the operatorStack has more precedence than or equal to token to pop operatorstack and and push to output
          giveOutput.push_back(daOperatorStack.top());
        }
        daOperatorStack.push(daTokens);
        tkn++;
    }
  }
  for (; !daOperatorStack.empty(); daOperatorStack.pop()) { //to input the second data pop and push back into the operator stack to calculate and return the output
    giveOutput.push_back(daOperatorStack.top());
  }
  giveOutput.reserve(input.size());//After finished iterating over the input , it reverse operatorStack and append it to the end of giveOutput vector. 
  return giveOutput;
}

int Calc::evalPostfix(const std::vector<Token>& tokens) {
  if (tokens.empty()) {
    return 0;
  }
  std::vector<int> stack;
  for (Token t : tokens) {
    if (t.type == 'n') {
      stack.push_back(t.val);
    } else {
      int val = 0;
      if (t.type == '+') {
        val = stack.back() + *(stack.end()-2);
      } else if (t.type == '*') {
        val = stack.back() * *(stack.end()-2);
      } else if (t.type == '-') {
        val = *(stack.end()-2) - stack.back();
      } else if (t.type == '/') {
        if (stack.back() == 0) {
          throw std::runtime_error("divide by zero");
        }
        val = *(stack.end()-2) / stack.back();
      } else {
          std::cout << "invalid token\n";
      }
      stack.pop_back();
      stack.pop_back();
      stack.push_back(val);
    }
  }
  return stack.back();
}

std::vector<Calc::Token> Calc::tokenise(const std::string& expression) {
  const std::vector<char> symbols = {'+', '-', '*', '/', '(', ')'};
  std::vector<Token> tokens {};
  for (std::size_t i = 0; i < expression.size(); ++i) {
    const char c = expression[i];
    // check if c is one of '+', '-', '*', '/', '(', ')'
    if (std::find(symbols.begin(), symbols.end(), c) != symbols.end()) {
      tokens.push_back({c});
    } else if (isdigit(c)) {
      // process multiple digit integers
      std::string num {c};
      while (i + 1 < expression.size() && isdigit(expression[i + 1])) {
        ++i;
        num.push_back(expression[i]);
      }
      tokens.push_back({'n', std::stoi(num)});
    }
  }
  return tokens;
}

int Calc::eval(const std::string& expression) {
  std::vector<Token> tokens = tokenise(expression);
  std::vector<Token> postfix = infixToPostfix(tokens);
  return evalPostfix(postfix);
}