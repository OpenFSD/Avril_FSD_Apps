#pragma once
#include <vector>

namespace Avril_FSD
{
    class GameInstance
    {
    public:
        GameInstance();
        virtual ~GameInstance();

        class Player* GetPlayer(__int8 playerId);

    protected:

    private:
        static void Set_player(class Player* player);
    };
}