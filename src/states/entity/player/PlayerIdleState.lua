--[[
    GD50
    Legend of Zelda

    Author: Colton Ogden
    cogden@cs50.harvard.edu
]]

PlayerIdleState = Class { __includes = EntityIdleState }

function PlayerIdleState:enter(params)
    -- render offset for spaced character sprite (negated in render function of state)
    self.entity.offsetY = 5
    self.entity.offsetX = 0
end

function PlayerIdleState:update(dt)
    if love.keyboard.isDown('left') or love.keyboard.isDown('right') or
        love.keyboard.isDown('up') or love.keyboard.isDown('down') then
        self.entity:changeState('walk')
    end

    if love.keyboard.wasPressed('space') then
        self.entity:changeState('swing-sword')
    elseif love.keyboard.wasPressed('return') then
        if self.entity.direction == 'left' then
            hitboxWidth = 8
            hitboxHeight = 16
            hitboxX = self.entity.x - hitboxWidth
            hitboxY = self.entity.y + 2
            liftPot = Hitbox(hitboxX, hitboxY, hitboxWidth, hitboxHeight)
        elseif self.entity.direction == 'right' then
            hitboxWidth = 8
            hitboxHeight = 16
            hitboxX = self.entity.x + self.entity.width
            hitboxY = self.entity.y + 2
            liftPot = Hitbox(hitboxX, hitboxY, hitboxWidth, hitboxHeight)
        elseif self.entity.direction == 'up' then
            hitboxWidth = 16
            hitboxHeight = 8
            hitboxX = self.entity.x
            hitboxY = self.entity.y - hitboxHeight
            liftPot = Hitbox(hitboxX, hitboxY, hitboxWidth, hitboxHeight)
        else
            hitboxWidth = 16
            hitboxHeight = 8
            hitboxX = self.entity.x
            hitboxY = self.entity.y + self.entity.height
            liftPot = Hitbox(hitboxX, hitboxY, hitboxWidth, hitboxHeight)
        end

        -- separate hitbox for the player's sword; will only be active during this state
        -- liftPot = Hitbox(hitboxX, hitboxY, hitboxWidth, hitboxHeight)
        for index, obj in ipairs(self.dungeon.currentRoom.objects) do
            if obj:collides(liftPot) and obj.texture == 'tiles' and obj.projectile == false then
                self.entity.Pot = obj
                obj.solid = false
                self.entity:changeState('lift-pot')
            end
        end
    end
end
