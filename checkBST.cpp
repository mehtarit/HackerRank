//Check if the tree is a binary subtree
/* Hidden stub code will pass a root argument to the function below. Complete the function to solve the challenge. Hint: you may want to write one or more helper functions.  

The Node struct is defined as follows:
   struct Node {
      int data;
      Node* left;
      Node* right;
   }
*/
bool checkBST(Node* root) {
      
       return checkBSTHelper(root, INT32_MIN, INT32_MAX);
   }

bool checkBSTHelper(Node* node, int min, int max)
{
    if(node == NULL) return true;
    if(node->data >=max || node->data <=min)return false;
    return checkBSTHelper(node->left, min, node->data) && checkBSTHelper(node->right, node->data, max);

}