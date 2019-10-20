#include "Sign.h"

namespace HuffmanTmp {

	Sign::Sign(char sign)
		: sign(sign) {


	} 

	Sign::Sign(char sign, int numOfOccurrences, Sign* leftNode, Sign* rightNode, int id)
		: sign(sign), numOfOccurrences(numOfOccurrences), leftNode(leftNode), rightNode(rightNode), id(id) {

	}

	Sign::Sign(): sign(sign), numOfOccurrences(numOfOccurrences), leftNode(leftNode), rightNode(rightNode) {
	}

	char Sign::GetSign() {
		return sign;
	}

	int Sign::GetNumOfOccurrences() {
		return numOfOccurrences;
	}

	void Sign::IncreaseNumOfOccurences() {
		Sign::numOfOccurrences++;
	}

	void Sign::SetNumOfOccurences(int numOfOccurences) {
		this->numOfOccurrences = numOfOccurences;
	}

	Sign* Sign::GetLeftNode() {
		return leftNode;
	}

	Sign* Sign::GetRightNode() {
		return rightNode;
	}

	void Sign::SetLeftNodeNull() {
		leftNode = nullptr;
	}

	void Sign::SetRightNodeNull() {
		rightNode = nullptr;
	}

	std::string Sign::GetCodedSign() {
		return codedSign;
	}

	void Sign::SetCodedSign(std::string coded) {
		codedSign = coded;
	}

	int Sign::GetId() {
		return id;
	}

}