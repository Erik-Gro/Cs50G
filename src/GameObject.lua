--[[
    GD50
    Legend of Zelda

    Author: Colton Ogden
    cogden@cs50.harvard.edu
]]

GameObject = Class {}

function GameObject:init(def, x, y)
    -- string identifying this object type
    self.type = def.type

    self.texture = def.texture
    self.frame = def.frame or 1
    self.projectile = false
    -- whether it acts as an obstacle or not
    self.solid = def.solid

    self.defaultState = def.defaultState
    self.state = self.defaultState
    self.states = def.states
    self.detele = false
    -- dimensions
    self.x = x
    self.y = y
    self.width = def.width
    self.height = def.height
    self.limit = 64
    self.brokentime = 190
    -- default empty collision callback
    self.onCollide = function() end
end

function GameObject:update(dt)
    if self.projectile and self.limit >= 0 then
        if self.x <= MAP_RENDER_OFFSET_X + TILE_SIZE or self.x + self.width >= VIRTUAL_WIDTH - TILE_SIZE * 2 or self.y <= MAP_RENDER_OFFSET_Y + TILE_SIZE - self.height / 2 or self.y + self.height >= VIRTUAL_HEIGHT - (VIRTUAL_HEIGHT - MAP_HEIGHT * TILE_SIZE)
            + MAP_RENDER_OFFSET_Y - TILE_SIZE then
            self.limit = 0
            self.delete = true
        end
        if self.direction == 'right' then
            self.x = self.x + 2
            self.limit = self.limit - 2
        end
        if self.direction == 'left' then
            self.x = self.x - 2
            self.limit = self.limit - 2
        end
        if self.direction == 'up' then
            self.y = self.y - 2
            self.limit = self.limit - 2
        end
        if self.direction == 'down' then
            self.y = self.y + 2
            self.limit = self.limit - 2
        end
        for key, value in pairs(self.entities) do
            if value:collides(self) then
                value:damage(1)
            end
        end
        if self.limit <= 0 then
            self.state = 'broken'
            self.delete = true
        end
    end
    if self.delete then
        self.brokentime = self.brokentime - 2
    end
end

function GameObject:collides(target)
    return not (self.x + self.width < target.x or self.x > target.x + target.width or
        self.y + self.height < target.y or self.y > target.y + target.height)
end

function GameObject:render(adjacentOffsetX, adjacentOffsetY)
    love.graphics.draw(gTextures[self.texture], gFrames[self.texture][self.states[self.state].frame or self.frame],
        self.x + adjacentOffsetX, self.y + adjacentOffsetY)
    -- love.graphics.rectangle('line', self.x, self.y,
    --     self.width, self.height)
end
