#include "CRCNativeWrapper.h"

extern "C" LIBRARY_EXPORT tmpCRC::CRC* new_CRC(const char* msg, const char* chosenCRC)
{
	std::string actualMsg = msg;
	std::string actualChosenCRC = chosenCRC;

	return new tmpCRC::CRC(actualMsg, actualChosenCRC);
}

extern "C" LIBRARY_EXPORT void delete_CRC(tmpCRC::CRC* instance)
{
	delete instance;
}

extern "C" LIBRARY_EXPORT int GetXORListLength(tmpCRC::CRC* instance)
{
	return instance->GetListOfXorOperations()->size();
}

extern "C" LIBRARY_EXPORT const char * GetXORResult(tmpCRC::CRC* instance, int wichOne)
{
	return  instance->GetListOfXorOperations()->at(wichOne).c_str();
}
