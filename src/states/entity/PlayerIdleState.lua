--[[
    GD50
    Super Mario Bros. Remake

    Author: Colton Ogden
    cogden@cs50.harvard.edu
]]

PlayerIdleState = Class { __includes = BaseState }

function PlayerIdleState:init(player)
    self.player = player

    self.animation = Animation {
        frames = { 1 },
        interval = 1
    }

    self.player.currentAnimation = self.animation
end

function PlayerIdleState:update(dt)
    if love.keyboard.isDown('left') or love.keyboard.isDown('right') then
        self.player:changeState('walking')
    end

    if love.keyboard.wasPressed('space') then
        self.player:changeState('jump')
    end
    -- for k, object in pairs(self.player.level.objects) do
    --     if object.texture == 'keys-locks' and object.consumable then
    --         self.player.hasKey = true
    --     end
    --     if object:collides(self.player) then
    --         if object.solid then
    --             object.onCollide(object)
    --             if self.player.hasKey and object.texture == 'keys-locks' then
    --                 self.player.blockWasDestroyed = true
    --             end
    --         end
    --     end
    -- end
    -- check if we've collided with any entities and die if so
    for k, entity in pairs(self.player.level.entities) do
        if entity:collides(self.player) then
            gSounds['death']:play()
            gStateMachine:change('start')
        end
    end
end
