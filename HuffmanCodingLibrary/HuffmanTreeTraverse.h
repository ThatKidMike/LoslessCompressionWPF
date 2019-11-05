#pragma once
#include "HuffmanTree.h"
#include <map>
#include <string>

namespace HuffmanTmp {

	class HuffmanTreeTraverse {

	private:
		Sign* previousNodePtr = nullptr;
		Sign* currentNodePtr = nullptr;
		std::string code = "";
		std::map<char, std::string> codedSigns;
		std::map<char, std::string>::iterator it = codedSigns.begin();

	public:
		HuffmanTreeTraverse(Sign* Apex);

		//Sign** GetCurrentNodePtr();
		std::map<char, std::string> GetCodedSigns();


	};


}