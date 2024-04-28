PlayerLiftPotState = Class { __includes = BaseState }

function PlayerLiftPotState:init(player, dungeon)
    self.player = player
    self.dungeon = dungeon

    self.player.offsetY = 5
    self.player.offsetX = 0

    local direction = self.player.direction
end

function PlayerLiftPotState:enter(pot)
    self:lift()
end

function PlayerLiftPotState:lift()
    self.player:changeAnimation('lift-pot-' .. self.player.direction)

    Timer.tween(0.30, {
        [self.player.Pot] = { x = self.player.x, y = self.player.y - 8 }
    }):finish(function()
        self.player:changeState('walk-pot')
    end)
end

function PlayerLiftPotState:update(dt)

end

function PlayerLiftPotState:render()
    local anim = self.player.currentAnimation
    love.graphics.draw(gTextures[anim.texture], gFrames[anim.texture][anim:getCurrentFrame()],
        math.floor(self.player.x - self.player.offsetX), math.floor(self.player.y - self.player.offsetY))
end
