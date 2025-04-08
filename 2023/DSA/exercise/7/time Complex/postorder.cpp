#include <vector>
#include <string>
#include <algorithm>
#include <stack>
#include "postorder.hpp"

std::vector<std::string> postorder(Node* root) {
  std::vector<std::string> output;
  if (root == nullptr) {
    return output;
  }
  std::stack<Node*> useStack;
  useStack.push(root);
  while (!useStack.empty()) {
    Node* cure = useStack.top();
    useStack.pop();
    output.push_back(cure->data);
    if (cure->left != nullptr) {
      useStack.push(cure->left);
    }
    if (cure->right != nullptr) {
      useStack.push(cure->right);
    }
  }
  std::reverse(output.begin(), output.end());
  return output;
}