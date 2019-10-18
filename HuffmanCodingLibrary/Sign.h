#pragma once
#include <string>

namespace HuffmanTmp {

	class Sign {

	private:
		char sign;
		int numOfOccurrences = 0;
		Sign* leftNode;
		Sign* rightNode;
		std::string codedSign;
		bool visited;
	public:
		Sign(char sign);
		Sign(char sign, int numOfOccurrences, Sign* leftNode, Sign* rightNode);
		Sign();

		char GetSign();
		int GetNumOfOccurrences();
		void IncreaseNumOfOccurences();
		void SetNumOfOccurences(int numOfOccurrences);
		Sign* GetLeftNode();
		Sign* GetRightNode();
		void SetLeftNodeNull();
		void SetRightNodeNull();
		std::string GetCodedSign();
		void SetCodedSign(std::string coded);
		
		void SetVisited();
		bool GetVisited();

		struct CustomPqComparator {

			bool operator() (Sign* s1, Sign* s2) {

				return s1->numOfOccurrences > s2->numOfOccurrences && s2->numOfOccurrences < s1->numOfOccurrences;

			}

		}; 

		bool operator<(const Sign& s) const {

			if (this->sign < s.sign) return true;
			else if ((this->sign == s.sign) && (this->sign < s.sign)) return true;
			else return false;

		}
		 
	};

}