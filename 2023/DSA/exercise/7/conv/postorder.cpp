#include <vector>
#include <string>
#include <algorithm>
#include "postorder.hpp"

std::vector<std::string> postorder(Node* root) {
  std::vector<std::string> output;
  if (root == nullptr) {
    return output;
  }
  std::vector<std::string> left = postorder(root->left);
  output.insert(output.end(), left.begin(), left.end());
  std::vector<std::string> right = postorder(root->right);
  output.insert(output.end(), right.begin(), right.end());
  output.push_back(root->data);
  return output;
}