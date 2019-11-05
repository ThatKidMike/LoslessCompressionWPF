#include "HuffmanTreeTraverse.h"
#include <iostream>
#include <string>

namespace HuffmanTmp {

	HuffmanTreeTraverse::HuffmanTreeTraverse(Sign* apex)
		: currentNodePtr(apex) {

		currentNodePtr = apex;

		while (!(apex->GetLeftNode() == nullptr && apex->GetRightNode() == nullptr))
		{

			if (currentNodePtr->GetRightNode() != nullptr)
			{
				previousNodePtr = currentNodePtr;
				currentNodePtr = currentNodePtr->GetRightNode();
				code += '1';

			}
			else if (currentNodePtr->GetLeftNode() != nullptr)
			{
				previousNodePtr = currentNodePtr;
				currentNodePtr = currentNodePtr->GetLeftNode();
				code += '0';
			}
			else
			{

				if (currentNodePtr->GetSign() != '#')
				{
					if (code[code.size() - 1] == '1')
					{
						previousNodePtr->SetRightNodeNull();
					}
					else if (code[code.size() - 1] == '0')
					{
						previousNodePtr->SetLeftNodeNull();
					}
					currentNodePtr->SetCodedSign(code);
					codedSigns.insert(it, std::pair<char, std::string>(currentNodePtr->GetSign(), code));
					code = "";
				}
				else if (currentNodePtr->GetSign() == '#')
				{
					if (code[code.size() - 1] == '1')
					{
						previousNodePtr->SetRightNodeNull();
					}
					else if (code[code.size() - 1] == '0')
					{
						previousNodePtr->SetLeftNodeNull();
					}
					code = "";
				}

				currentNodePtr = apex;

			}

		}

		for (auto it = codedSigns.cbegin(); it != codedSigns.cend(); ++it)
		{
			std::cout << it->first << " : " << it->second << "\n";
		}

	}


	/*	Sign** HuffmanTreeTraverse::GetCurrentNodePtr() {
			return currentNodePtr;
		} */

	std::map<char, std::string> HuffmanTreeTraverse::GetCodedSigns() {
		return codedSigns;
	}




}